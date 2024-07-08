
extends TileMap

# Define your enemy spawn tile ID here
var curr_map_size
var corner
var grace_area
func _ready():
	
	grace_area = $"../WizardPlayer/GraceArea"
	print(grace_area)
	curr_map_size = get_used_rect().size
	corner = get_used_rect().position #-16, -10
	
	
	#spawn_enemy(Vector2(15,8))

func  get_random_x():
	var rand_x = randi_range(1, curr_map_size.x - 2)
	return rand_x

func  get_random_y():
	var rand_y = randi_range(1, curr_map_size.y - 2)
	return rand_y
	

# working
func get_random_pos_in_map():
	var rand_x =  get_random_x()
	var rand_y =  get_random_y()
	
	var rng_spawn_pos: Vector2 =  Vector2(rand_x + corner.x , rand_y + corner.y)
	if (rng_spawn_pos*64).distance_to(grace_area.global_position) > 390:
		spawn_enemy(rng_spawn_pos)

#wokring
func spawn_enemy(pos):
	# Example function to spawn an enemy at a given position
	var enemy_instance = preload("res://Scenes/Nodes/Slime.tscn").instantiate()
	enemy_instance.global_position.x = pos.x * 64
	enemy_instance.global_position.y = pos.y * 64
	get_parent().add_child.call_deferred(enemy_instance)
	

func _on_timer_timeout():
	get_random_pos_in_map()
	get_random_pos_in_map()
