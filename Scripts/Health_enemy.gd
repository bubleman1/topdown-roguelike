extends ProgressBar

var max_value_amount
var min_value_amount
var healthComponent
# Called when the node enters the scene tree for the first time.
func _ready():
	healthComponent = $"../HealthComponent"
	max_value_amount = healthComponent.Health
	min_value_amount = 0

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	self.value = (healthComponent.Health/max_value_amount) * 100
	if healthComponent.Health != max_value_amount:
		self.visible = true
		if healthComponent.Health == min_value_amount:
			self.visible = false
	else: self.visible = false
