# WoodGrainEffect
This Windows Forms app rewrites a gcode file created by Cura, changing temperatures throughout the print, to create a random wood grain effect in the finished print.

It accomplishes this by changing the temperature of your hotend/nozzle throughout the print job. It will create "bands" of different temperatures, resulting in slightly different coloration of your filament. The bands are random heights between 1 and 4 mm. Each time it starts a new band, it will chose a random temperature, alternating between ranges in the top third and then in the bottom third of the overall span you defined. It will also preserve your original temperature in the bottom 2mm and the top 2mm of your print.

* IMPORTANT NOTE: Be sure you understand the limitations of your printer when setting the upper temperature! Applying a temperature which is too high can be dangerous to your printer and to your health (it can cause gases which are dangerous to breathe).

This was created using gcode files generated by Ultimaker Cura version 5.2.1 without any other extensions/plugins applied. So, a basic file with one temperature defined throughout. I cannot speak to what may occur if you use this app on other gcode files.

My testing was done with Priline wood PLA 1.75mm filament (the lighter color filament) and was printed through a 0.4mm nozzle.

The app uses .NET 8 framework.
