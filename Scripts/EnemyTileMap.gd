
extends TileMap

# Define your enemy spawn tile ID here
const ENEMY_SPAWN_TILE_ID = Vector2i(0,0)  # Replace '1' with the actual tile ID from your tileset

func _ready():
	# Iterate through all used cells (tiles placed on the tilemap)
	for cell in get_used_cells(1):
		# Check the tile ID to determine if it's an enemy spawn point
		var tile_id = get_cell_atlas_coords(1, cell)
		if tile_id == ENEMY_SPAWN_TILE_ID:
			# Calculate the world position of the tile
			var tile_position = map_to_local(Vector2(cell.x, cell.y) * 128)
			# Spawn an enemy at the calculated position
			spawn_enemy(tile_position)

func spawn_enemy(pos):
	# Example function to spawn an enemy at a given position
	var enemy_instance = preload("res://Scenes/Nodes/Slime.tscn").instantiate()
	enemy_instance.position = pos
	get_parent().add_child.call_deferred(enemy_instance)
