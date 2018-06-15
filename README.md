Copy "DemoRecorder.exe" to your base Urban Terror 4.2 folder.

When you run it, it will go through all demos in your "q3ut4\demos" folder and will
automatically call "vstr videogui" and "video" with each demo.

Move any undesired demos to another folder, such as "demos\notspecialenough."

"videogui" is a user-defined setting that you will place in your q3config file.

Below is what I use. Feel free to change it to your liking.

seta videogui "cg_draw2d 0; cg_msgtime 0; cg_chattime 0; cg_gunx 10; cg_guny -20; cg_gunz 5; cg_gunx 0; cg_guny 10; cg_gunz 5"