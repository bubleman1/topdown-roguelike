extends CharacterBody2D

@export var health = 100
@export var damage = 10
@export var knockback = 15 #knockback player
@export var s_knockback = 5 #knockback itself

var  slime_knockback = Vector2.ZERO
var speed = 150
var player_chase = false
var player = null
var animatedSprite2D
signal has_been_hit(sender, target)


func _ready():
	add_to_group("enemy")
	animatedSprite2D = $AnimatedSprite2D
	
func _physics_process(_delta):
	if player_chase:
		velocity.x = player.position.x - position.x
		velocity.y = player.position.y - position.y
		velocity = velocity.normalized() * speed + slime_knockback
		move_and_collide(velocity * _delta)
		animatedSprite2D.play("slime_run")
	else:
		animatedSprite2D.play("slime_idle")
	slime_knockback = slime_knockback.lerp(Vector2.ZERO, 0.1)
	


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
		health -= area.Damage
		if health <= 0:
			queue_free()
	if area.is_in_group("player"):
		player.Health -= damage
		player.Knockback = velocity * knockback
		slime_knockback = -velocity * s_knockback
		
