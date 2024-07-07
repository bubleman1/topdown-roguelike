extends CharacterBody2D

@export var damage = 10
@export var knockback = 15 #knockbacks player
@export var s_knockback = 5 #knockbacks itself

@export var max_health = 500
var min_health = 0
var curr_health

var is_alive = true
var  slime_knockback = Vector2.ZERO
var speed = 150

var player_chase = false
var player = null

var animatedSprite2D
signal has_been_hit(sender, target)


func _ready():
	add_to_group("enemy")
	animatedSprite2D = $AnimatedSprite2D
	curr_health = max_health
	
func _physics_process(_delta):
	if is_alive == false:
		return
	
	if player_chase:
		velocity.x = player.position.x - position.x
		velocity.y = player.position.y - position.y
		velocity = velocity.normalized() * speed + slime_knockback
		move_and_collide(velocity * _delta)
		animatedSprite2D.play("slime_run")
		if (player.position.x - position.x) < 0 :
			animatedSprite2D.flip_h = true
		else:
			animatedSprite2D.flip_h = false
			
	else:
		animatedSprite2D.play("slime_idle")
	slime_knockback = slime_knockback.lerp(Vector2.ZERO, 0.1) # knockback goes towards (0, 0) higher 
															  # const less knockback
	


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
		player.Health -= damage
		player.Knockback = velocity * knockback
		slime_knockback = -velocity * s_knockback

func die():
	if is_alive == false:
		return
	is_alive = false
	velocity =  Vector2(0,0) # remove movement
	$Area2D.queue_free()    # remove hitbox
	animatedSprite2D.play("slime_death")

func _on_animated_sprite_2d_animation_finished():
	if animatedSprite2D.animation == "slime_death": # on end of animation remove entity
		queue_free()
