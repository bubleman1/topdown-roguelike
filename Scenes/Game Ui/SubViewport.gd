extends SubViewport


@onready var camera = $Camera2D

var player_node_path: NodePath
var player_marker_path: NodePath

func _ready():
	player_node_path = "../../../WizardPlayer"
	player_marker_path = "../PlayerMarker"
	
func _process(_delta):
	var player = get_node(player_node_path)
	var player_marker = get_node(player_marker_path)
	if !player: return
	else:player_marker.rotation = player.rotation + PI/2

func _physics_process(_delta):
	var player = get_node(player_node_path)
	if player:
		camera.position = player.position
	else:
		print("Player not found") 
