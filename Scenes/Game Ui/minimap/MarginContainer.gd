extends MarginContainer
#Minimap is not working you can delete this
@export var zoom = 1.5
@export var x = 1000

var player_node_path: NodePath

@onready var grid = $MarginContainer/Grid
@onready var player_marker = $MarginContainer/Grid/Sprite2D

var grid_scale

func _ready():
	player_marker.position.y = 100
	player_marker.position.x = 100
	
	
	grid_scale = grid.size  / (get_viewport_rect().size * zoom)

#func _process(delta):
	#pass
