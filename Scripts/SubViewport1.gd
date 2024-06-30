extends SubViewport

@onready var camera = $Camera2D
var player_node_path: NodePath

func _ready():
	player_node_path = "../../../WizardPlayer"

func _physics_process(_delta):
	var player = get_node(player_node_path)
	if player:
		camera.position = player.position
	else:
		print("Player not found")
