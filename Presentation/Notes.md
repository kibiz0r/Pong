# Test-Driving Pong
## Basic Workflow
n. Extract the essential rules of Pong.
	* When the game starts, each player gets a paddle spawned in the middle of their goal
	* When the game starts, a ball spawns in the middle of the field, with a random direction and base speed
	* When the ball enters a goal, it respawns in the middle of the field, with a random direction and base speed
	* When the ball enters a goal, the other player gets a point
	* When a paddle passes the top or bottom of the screen, it is clamped to that edge
	* When a player presses "up", their paddle moves up
	* When a player presses "down", their paddle moves down
	* When a player presses nothing, their paddle slows to a stop
	* When the ball hits a paddle, it reverses X-direction, inherits some portion of the paddle's Y velocity, and increases its X velocity slightly
	* When a player joins, they are assigned a position
	* When the last player joins, the game starts

n. Pick the simplest rule.
	* We're making baby steps here, people.
	* I chose "When the last player joins, the game starts" because covering the transition from *waiting* to *playing* opens up new possibilities.

n. Write an integration test that exercises that rule.
	* GameStart.feature: The game starts when two players join
	* An integration test covers a single scenario end-to-end. *i.e. Two players join the game, Player 1 reflects the ball, Player 2 misses, Player 1 scores.*
	* It should be written in a way that a non-technical person could understand it.
	* It generally calls multiple methods on the API, putting the program through a sequence of different states.
	* Generally, only "happy path" cases are described in integration tests.
	* Integration tests talk about how the user interacts with the system, from the perspective of the user. They are, therefore, a crude form of a user manual.

n. Decompose integration test into one or more functional tests.
	* A functional test describes a single high-level interaction with the program. *i.e. Player 1 joins the game, the game should have one player set up.*
	* It generally represents calling a single method on the API, and specifies what happens as a result when the program is in different states.
	* It may cover degenerate cases, where a particular method is disallowed in the program's current state.
	* Functional tests usually don't use mocks if they can help it.
	* Through writing a functional test, you will describe what input is required for a particular action and what output or state change is observed as a result.
	* Functional tests talk about how the system changes in response to a single input, from the perspective of the system itself. They are, therefore, the programmer's documentation of what high-level types, states, and interactions describe the system.
	* Functional tests should remain highly decoupled from implementation details.

n. Decompose functional tests into several unit tests.
	* A unit test describes the behavior of a single method of a class. *i.e. PaddleMover moves the paddle, given a direction, velocity and time span.*
	* Generally, each test case only covers a single method being called once with a specific set of inputs, expecting a specific output or state change.
	* It should cover all possible states and inputs, both normal and exceptional.
	* Unit tests may make extensive use of mocks to decouple them from other objects.
	* Unit tests are tightly coupled to implementation details of their subject class, but should be agnostic to implementation of other classes/dependencies.

n. Write code to the meet the first unit test.
	* Follow the Extreme Programming principle "Do The Simplest Thing That Could Possibly Work".
		* Don't write more code than you need to in order to pass the first test.
		* Don't build a giant extensible system before a test case proves that you need it.
	* Red/Green/Refactor.
		* Red: Write the test, watch it fail.
		* Green: Write the simplest possible solution that passes all the tests.
		* Refactor: Experiment with different designs, rip out existing methods, etc. Have no fear -- all existing code is tested, so we will know if we have broken something in the process.
	* Keep it DRY: "Don't Repeat Yourself".
		* If you find yourself copying and pasting code, or writing very similar code in two different places, consider an abstraction that simplifies the code.
	* YAGNI: "You aren't gonna need it."
		* "Always implement things when you actually need them, never when you just foresee that you need them."
		* You save time, because you avoid writing code that you turn out not to need.
		* Your code is better, because you avoid polluting it with 'guesses' that turn out to be more or less wrong but stick around anyway.
> You're working on some class. You have just added some functionality that you need. You realize that you are going to need some other bit of functionality. If you don't need it now, don't add it now. Why not?
> 
> "OK, Sam, why do you want to add it now?"
> 
> "Well, Ron, it will save time later."
> 
> But unless your universe is very different from mine, you can't 'save' time by doing the work now, unless it will take more time to do it later than it will to do now. So you are saying:
> 
> "We will be able to do less work overall, at the cost of doing more work now."
> 
> But unless your project is very different from mine, you already have too much to do right now. Doing more now is a very bad thing when you already have too much to do.
> 
> And unless your mind is very different from mine, there is a high chance that you won't need it after all, or that you'll need to rewrite or fix it once you do need it. If either of these happens, not only will you waste time overall, you will prevent yourself from adding things that you do need right now.
> 
> "But Ron, I know how to do it right now, and later I might not."
> 
> "So, Sam, you're telling me that this class you're writing is so complex that even you won't be able to maintain it?"
> 
> Keep it simple. If you need it, you can put it in later. If you don't need it, you won't have to do the work at all. Take that day off.

n. Fulfill unit tests until the first functional test passes.
n. Fulfill functional tests until the first integration test passes.
n. Repeat until you run out of features, time, or money!

## Visualizing The Game
You may have noticed that, while our tests verify that we have a working implementation of Pong's game mechanics, we don't have anything visual or playable.

This is because our test cases are pretending the be the player -- interpreting and changing the game state as if it were a human being playing the game -- and the test cases don't need a keyboard or fancy graphics to do their job.

Designing input and rendering code is still mostly a matter of intuition, and verifying it requires manual testing. Therefore, both of these are potential sources of bugs, wasted time, code smells, and anti-patterns. They are also difficult to debug and probably have a greater effect on the user experience than more testable parts of a game.

Therefore we should strive to:

* Have as little code in the input/view layer as possible.
* Keep a strict separation between game logic and input/view code.
* Limit the number of objects that directly interact with the input/drawing API. (Test runners don't handle input or graphical processes very well, so objects that require use of an API like DirectX/OpenGL/etc. cannot be used in the test environment.)
	* This has implications in the Unity world: certain Unity APIs are unavailable without an active Unity session, and objects that use them must be mocked out in your test environment. This sucks if the object normally performs a lot of useful logic, so avoiding contaminating such objects with input/drawing code.

It's important to add in visualization early, to see the practical effects of your efforts and to supplement the quantitative output of your test cases with the qualitative output of your display.

Remember: as useful as automated testing is, it's not a replacement for first-hand experience.

In designing our visualization, we might consider that the game view is an interpretation of the game state, therefore it should be possible to have the game view display any arbitrary game state we want. If that is true, then we can take the result of an automated test and display it on the screen, giving us more information to debug with when a test fails. We could also load the game state from a file, allowing us to easily walk through pre-determined scenarios without going through the effort of playing through the game to get to the right spot or resorting to special "developer mode" tools.