
extends TileMap

# Define your enemy spawn tile ID here
const ENEMY_SPAWN_TILE_ID = Vector2i(0,0)  # Replace '1' with the actual tile ID from your tileset
var curr_map_size
var corner
func _ready():
	#for cell in get_used_cells(1):
		## Check the tile ID to determine if it's an enemy spawn point
		#var tile_id = get_cell_atlas_coords(1, cell)
		#if tile_id == ENEMY_SPAWN_TILE_ID:
			## Calculate the world position of the tile
			#var tile_position = map_to_local(Vector2(cell.x, cell.y))
			## Spawn an enemy at the calculated position
			#spawn_enemy(tile_position)
			
	curr_map_size = get_used_rect().size
	corner = get_used_rect().position
	print(corner)
	for x in 10:
		get_random_pos_in_map()
	#spawn_enemy(Vector2(15,8))


# working
func get_random_pos_in_map():
	var rand_x = randi_range(1, curr_map_size.x - 2)
	var rand_y = randi_range(1, curr_map_size.y - 2)
	var rng_spawn_pos: Vector2 =  Vector2(rand_x + corner.x , rand_y + corner.y)
	spawn_enemy(rng_spawn_pos)
#wokring
func spawn_enemy(pos):
	# Example function to spawn an enemy at a given position
	var enemy_instance = preload("res://Scenes/Nodes/Slime.tscn").instantiate()
	enemy_instance.global_position.x = pos.x * 64
	enemy_instance.global_position.y = pos.y * 64
	get_parent().add_child.call_deferred(enemy_instance)
	
	print(pos)
