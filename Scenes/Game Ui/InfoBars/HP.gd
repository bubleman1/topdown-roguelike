extends ProgressBar

var player_node_path: NodePath
var player
var hp = 1

# Called when the node enters the scene tree for the first time.
func _ready():
	player_node_path = "../../../../WizardPlayer"
	player = get_node(player_node_path)
	hp = player.Health


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
