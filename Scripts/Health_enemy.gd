extends ProgressBar

var parent
var max_value_amount
var min_value_amount

# Called when the node enters the scene tree for the first time.
func _ready():
	parent =  get_parent()
	max_value_amount = parent.max_health
	min_value_amount = parent.min_health

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	self.value = (parent.curr_health/parent.max_health) * 100
	if parent.curr_health != max_value_amount:
		self.visible = true
		if parent.curr_health == min_value_amount:
			self.visible = false
	else: self.visible = false
