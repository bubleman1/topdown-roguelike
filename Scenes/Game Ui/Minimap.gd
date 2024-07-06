extends SubViewportContainer
#Minimap is not working you can delete this

@onready var camera = $SubViewport/Camera2D
@onready var player_marker = $PlayerMarker

var player_node_path: NodePath

func _ready():
	player_node_path = "../../../WizardPlayer"
	
func _process(_delta):
	var player = get_node(player_node_path)
	if !player: return
	else:player_marker.rotation = player.rotation + PI

func _physics_process(_delta):
	var player = get_node(player_node_path)
	if player:
		camera.position = player.position
	else:
		print("Player not found") 
