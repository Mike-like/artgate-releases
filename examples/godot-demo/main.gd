extends Node2D
## Shows the game's art through artgate's index: the hero's walk animations and every icon.
## Placeholders until real art arrives; after `artgate apply`, the same code shows the real art,
## including any frames the artist added.


func _ready() -> void:
	var missing := ArtIndex.FRAMES.keys().filter(func(base): return ArtIndex.is_placeholder(base))
	print("%d animations still use placeholders; coin icon listed: %s" % [missing.size(), ArtIndex.has("ui/icon_coin")])

	var x := 120.0
	for base in ArtIndex.FRAMES:
		var sprite := AnimatedSprite2D.new()
		sprite.sprite_frames = ArtIndex.sprite_frames([base])
		sprite.position = Vector2(x, 140)
		sprite.play(base)
		add_child(sprite)
		x += 96.0

	x = 60.0
	for key in ArtIndex.IMAGES:
		if key.begins_with("ui/"):
			var icon := Sprite2D.new()
			icon.texture = ArtIndex.texture(key)
			icon.position = Vector2(x, 40)
			add_child(icon)
			x += 48.0
