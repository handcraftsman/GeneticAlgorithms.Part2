## Genetic Algorithms - Hello World!

This is the C# source code for [part 1 of my series on genetic algorithms][part1].

In this part we build a genetic solver that can reproduce a string, e.g. "Hello World!", without direct access to the the string. It does this by calling a fitness function with a guess.  The fitness function returns an integer value representing how many of the characters in the string are correct, but not which ones - somewhat like the game Hang Man.

Sample run:

	generation        1 fitness     0 kvKpQyvswupQ    elapsed: 00:00:00.0165527
	generation        8 fitness     1 kvlpQyvswupQ    elapsed: 00:00:00.0226154
	generation       91 fitness     2 HvlpQyvswupQ    elapsed: 00:00:00.0229475
	generation      121 fitness     3 HvlpQyvswup!    elapsed: 00:00:00.0232349
	generation      215 fitness     4 HvlpQyWswup!    elapsed: 00:00:00.0235339
	generation      362 fitness     5 HelpQyWswup!    elapsed: 00:00:00.0238476
	generation      582 fitness     6 HelpQyWswud!    elapsed: 00:00:00.0241865
	generation      635 fitness     7 HelpQyWswld!    elapsed: 00:00:00.0244760
	generation      668 fitness     8 HellQyWswld!    elapsed: 00:00:00.0247558
	generation      835 fitness     9 HellQyWowld!    elapsed: 00:00:00.0251136
	generation     1024 fitness    10 HelloyWowld!    elapsed: 00:00:00.0254617
	generation     1217 fitness    11 Hello Wowld!    elapsed: 00:00:00.0257942
	generation     2645 fitness    12 Hello World!    elapsed: 00:00:00.0264738
	Hello World!
	
## License		

[MIT License][mitlicense]

[mitlicense]: http://www.opensource.org/licenses/mit-license.php
[part1]: http://handcraftsman.wordpress.com/2011/05/27/genetic-programming-hello-world/
