extends CharacterBody2D


@export var max_health = 5
var min_health = 0
var curr_health
var detectionComponent
var hurtboxComponent
var velocityComponent
var is_alive = true
var enemy_size = 6
var animatedSprite2D


func _ready():
	add_to_group("enemy")
	
	animatedSprite2D = $AnimatedSprite2D
	scale.x = enemy_size
	scale.y = enemy_size
	curr_health = max_health

	detectionComponent = $DetectionComponent
	hurtboxComponent = $HurtboxComponent
	velocityComponent = $VelocityComponent
	hurtboxComponent.connect(hurtboxComponent.DeadSignalName, _on_dead)
	
func _physics_process(_delta):
	if is_alive == false:
		return
	
	if detectionComponent.Player!=null:
		velocityComponent.Speed = 300
		velocityComponent.GoTo(detectionComponent.Player.position)
		animatedSprite2D.play("slime_run")
		if velocityComponent.Velocity.x < 0:
			animatedSprite2D.flip_h = true
		else:
			animatedSprite2D.flip_h = false
			
	else:
		animatedSprite2D.play("slime_idle")
		velocityComponent.Speed = 75
		velocityComponent.RandomMovement(_delta)
	velocityComponent.ProcessVelocity()
	move_and_collide(velocityComponent.Velocity * _delta)
		
	velocityComponent.ProcessKnockback() # knockback goes towards (0, 0) higher 
															  # const less knockback

func _on_dead():
	die()
	
func die():
	if is_alive == false:
		return
	is_alive = false
	velocity =  Vector2(0,0) # remove movement
	$HurtboxComponent.queue_free()    # remove hitbox
	$CollisionShape2D.queue_free()
	animatedSprite2D.play("slime_death")

func _on_animated_sprite_2d_animation_finished():
	if animatedSprite2D.animation == "slime_death": # on end of animation remove entity
		queue_free()
