extends CharacterBody2D


@export var max_health = 50
var min_health = 0
var curr_health
var detectionComponent
var hurtboxComponent
var velocityComponent
var is_alive = true
<<<<<<< Updated upstream
=======
var  slime_knockback = Vector2.ZERO
var speed = 150

var player_chase = false
var player = null

@export var enemy_size = 4
>>>>>>> Stashed changes
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
		velocityComponent.GoTo(detectionComponent.Player.position)
		velocityComponent.ProcessVelocity()
		move_and_collide(velocityComponent.Velocity * _delta)
		animatedSprite2D.play("slime_run")
		if velocityComponent.Velocity.x < 0:
			animatedSprite2D.flip_h = true
		else:
			animatedSprite2D.flip_h = false
			
	else:
		animatedSprite2D.play("slime_idle")
	velocityComponent.ProcessKnockback() # knockback goes towards (0, 0) higher 
															  # const less knockback
	
<<<<<<< Updated upstream
func _on_dead():
	die()
	
=======


func _on_detection_area_body_entered(body):
	if body.is_in_group("player"):
		player = body
		player_chase = true


func _on_detection_area_body_exited(body):
	if body.is_in_group("player"):
		player = null
		player_chase = false




func _on_area_2d_area_entered(area):
	if area.is_in_group("projectile"):
		curr_health -= area.Damage
		#slime_knockback = area.Velocity * s_knockback
		if curr_health <= 0:
			die()
	if area.is_in_group("player"):
		if player:
			player.Health -= damage
			player.Knockback = velocity * knockback
			slime_knockback = -velocity * s_knockback

>>>>>>> Stashed changes
func die():
	if is_alive == false:
		return
	is_alive = false
	velocity =  Vector2(0,0) # remove movement
<<<<<<< Updated upstream
	$HurtboxComponent.queue_free()    # remove hitboxd
=======
	$Area2D.queue_free()    # remove hitbox
	$CollisionShape2D.queue_free()
	$detection_area.queue_free()
	$HealthEnemy.queue_free()
>>>>>>> Stashed changes
	animatedSprite2D.play("slime_death")

func _on_animated_sprite_2d_animation_finished():
	if animatedSprite2D.animation == "slime_death": # on end of animation remove entity
		queue_free()
