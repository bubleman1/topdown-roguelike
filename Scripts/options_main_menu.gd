extends Control

func _on_back_pressed():
	get_tree().change_scene_to_file("res://Scenes/main_menu.tscn")
	
func _on_full_screen_button_toggled(button_pressed):
	if button_pressed == true:
		DisplayServer.window_set_mode(DisplayServer.WINDOW_MODE_FULLSCREEN)
	else:
		DisplayServer.window_set_mode(DisplayServer.WINDOW_MODE_WINDOWED)
