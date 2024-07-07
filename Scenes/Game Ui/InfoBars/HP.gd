extends ProgressBar

var player_node_path: NodePath
var player

# Called when the node enters the scene tree for the first time.
func _ready():
	player_node_path = "../../../../WizardPlayer"
	player = get_node(player_node_path)


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta):
	value = player.healthComponent.Health
