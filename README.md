# UO CS410 - Assignment 2 #

People: Abie Safdie, Jerry, Angel, Zach


asafdie11@gmail.com


# Description of Project

	John Lemon is trapped in a haunted house and needs to find their way out! Use WASD to move and try and find the exit while avoiding the gargoyles and ghosts, which will restart the game if they catch you! 

	Lerp feature by Abie and Zach
	Dot Product by Angel
	Particle by Jerry

# Lerp

	John Lemon has a pet sphere! It uses lerp to change color, and progressivley turns from blue 
to red as John gets closer to the exit. However, the pet sphere is not that intelligent and you may 
have to get "colder" in order to get "warmer".

	The lerp is calculated based on the sum of the x and z position of John divided by the sum of the x and z position of the exit.

# Dot Product
	Enemies now use the dot product to determine wether or not John Lemon is inside a cone field
of view. We still check however if there are any walls or other objects blocking the line of sight.
Whenever John Lemon walks into the line of sight cone (which has a prederetmined size), the game will
end since this means he has been seen and got caught.  

# Particle Effect
	John Lemon now has a pink particle effect at his feet that will follow him wherever he goes! 
This particle effect will activate at the beginning of the game and will remain active until John
Lemon Gets caught or escapes. 


