## 8 Queens Puzzle – Genetic Algorithms 2

This is the C# source code for [part 2 of my series on genetic algorithms][part2].

In this part we extend the solver we built in [part 1][part1] to solve a problem for which there are multiple correct answers - the [8 Queens Puzzle][wikipedia].  This puzzle asks us to place 8 Chess Queens on a chess board such that none of them are under attack.

Sample output:

	. . . . . . . . 
	. . . . . . . . 
	. . . . . . . . 
	. . . . Q . . .
	Q Q . . . . Q . 
	. . Q . . . . .
	. . . . . . . . 
	. . . . . . . . 
	generation          1 fitness   30008 elapsed: 00:00:00.1161487
	. . . . Q Q Q . 
	. . . . . . . . 
	. . . . . . . . 
	. . . . . . . . 
	Q Q . . . . . . 
	. . Q . . . . Q
	. . . . . . . . 
	. . . . . . . . 
	generation          1 fitness   10014 elapsed: 00:00:00.1220378
	. . Q . . . . .
	. . . . . . . . 
	. . . . . . . . 
	Q . . . . . . Q
	Q . . Q . . . . 
	. . Q . . . . .
	. . . Q . . . . 
	. . Q . . . . .
	generation          1 fitness   20 elapsed: 00:00:00.1248852
	. . . . Q . . Q
	. . Q . . . . .
	. . . . . Q . . 
	. . . . . . . . 
	. . . . . . . . 
	. . . Q . . . . 
	. . . . Q Q . . 
	. . Q . . . . .
	generation          1 fitness   14 elapsed: 00:00:00.1344589
	. . . . . . . . 
	. . . . . . . . 
	. . . Q Q . . .
	. . . . . . Q . 
	. . Q . . . . .
	. Q . . . Q . . 
	Q . . . . . . .
	. . . . . . . Q 
	generation          1 fitness   12 elapsed: 00:00:00.1451020
	Q . . . Q . . .
	. . . . . . Q . 
	. . . . Q . . .
	. . Q . . . . .
	. Q . . . Q . . 
	. . . . . . . . 
	. . . . Q . . .
	. . . . . . . . 
	generation          1 fitness   10 elapsed: 00:00:00.1546707
	Q . . . Q . . .
	. . . . . . Q . 
	. . . . Q . . .
	. . Q . . . . .
	. . . . . Q . . 
	. Q . . . . . . 
	. . . . Q . . .
	. . . . . . . . 
	generation          2 fitness    8 elapsed: 00:00:00.2066084
	. . . . Q . . .
	. . . . . . Q . 
	. . . . Q . . .
	. . Q . . . . .
	. . . . . Q . . 
	. Q . . . . . . 
	. . . . Q . . .
	. . . . . . . Q 
	generation          3 fitness    6 elapsed: 00:00:00.2303158
	Q . . . . . . .
	. . . . . . Q . 
	. . . . . . Q . 
	. . Q . . . . .
	. . . . . Q . Q 
	. Q . . . . . . 
	. . . . Q . . .
	. . . . . . . . 
	generation         21 fitness    4 elapsed: 00:00:00.7416604
	. . . Q . . . . 
	. . . . . . Q . 
	. . . . . . Q . 
	. . Q . . . . .
	. . . . . Q . . 
	. Q . . . . . . 
	. . . . Q . . .
	. . . . . . . Q 
	generation         99 fitness    2 elapsed: 00:00:02.7303553
	. . . Q . . . . 
	. . . . . . . Q 
	Q . . . . . . .
	. . Q . . . . .
	. . . . . Q . . 
	. Q . . . . . . 
	. . . . . . Q . 
	. . . . Q . . .
	generation        316 fitness    0 elapsed: 00:00:06.9379407
	A8pdL2Pq

## License		

[MIT License][mitlicense]

[mitlicense]: http://www.opensource.org/licenses/mit-license.php
[part1]: http://handcraftsman.wordpress.com/2011/05/27/genetic-programming-hello-world/
[part2]: http://handcraftsman.wordpress.com/2011/06/04/genetic-programming-part-2-8-queens/
[wikipedia]: http://en.wikipedia.org/wiki/Eight_queens_puzzle