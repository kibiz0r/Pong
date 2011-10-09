# What is TDD?
> Test-driven development (TDD) is a software development process that relies on the repetition of a very short development cycle: first the developer writes a failing automated test case that defines a desired improvement or new function, then produces code to pass that test and finally refactors the new code to acceptable standards.

# Why do TDD?
* Forces you to adopt the perspective of the *user* -- both of your code and of your application.
* Forces you to describe the intended behavior *prior* to implementing the behavior, making it more difficult for behavior to arise from happenstance. ("Interface before implementation.")
* Produces less ambiguous documentation that is less likely to become stale.
* Reduces your dependence on debuggers.
* Lets you move faster.
* It tends to be harder to write bad code.
* Classes tend to be smaller, more focused, and more loosely coupled, with cleaner interfaces.
* Free regression testing.
* It's cheaper and easier to fix bugs earlier.
* Allows sustainable development. (As long as all the tests pass, the project is shippable. No crunch time, no "bugfixing phase", no "maintenance phase" since maintenance is the same as continued development.)
* Easier bugfix workflow: Write a test case to represent the scenario, see it fail, fix the bug, see it pass.
* Higher code coverage than testing after the fact.
* Increases confidence in the codebase.
* Lets you refactor ruthlessly.
* Allows newbie developers to write decent code.
* Allows non-technical members to interact with the codebase by writing plain-English test cases.
* Provides visibility of the current state of the project.
* And, of course, verifies the correctness of your code (which you would be doing anyway).
* Also, it's more fun!

# What is a test?
A test is simply an assertion about the behavior of a particular piece of code.

	[TestFixture]
	public class CalculatorTest
	{
		[Test]
		public void AddTest()
		{
			var calculator = new Calculator();
			var result = calculator.Add(3, 8);
			Assert.That(result, Is.EqualTo(11));
		}
	}

Output before we implement Add():
	F
	Tests run: 1, Errors: 0, Failures: 1, Inconclusive: 0, Time: 0.337824 seconds
	  Not run: 0, Invalid: 0, Ignored: 0, Skipped: 0

	Errors and Failures:
	1) Test Failure : Calculator.Test.CalculatorTest.AddTest
	     Expected: 11
	     But was:  0

Output after we implement Add():
	.
	Tests run: 1, Errors: 0, Failures: 0, Inconclusive: 0, Time: 0.337824 seconds
	  Not run: 0, Invalid: 0, Ignored: 0, Skipped: 0

# How do I test?
There are two main approaches to testing. They are characterized as "state-based" (or black-box) and "interaction-based" (or white-box). They offer complementary benefits, and are often used in conjunction to fully test a feature.

## State-based testing
State-based testing relies on putting the object under test into a known state, triggering a state change, and then asserting some facts about its new state.

	var door = new Door(DoorState.Closed); // Door is initially closed.
	door.Open();
	Assert.That(door.State, Is.EqualTo(DoorState.Open));

The earlier example of the calculator is also a state-based test.

	var calculator = new Calculator();
	var result = calculator.Add(3, 8);
	Assert.That(result, Is.EqualTo(11));

## Interaction-based testing
Interaction-based testing, on the other hand, specifies how an object interacts with its dependencies. Here, we are less concerned with the state of any particular object -- we just want to ensure that the right calls are being made with the right arguments.

In this example, we are testing our DamageDealer class, which will ask our guy how much armor he has and then deal him the remaining damage.

	var guy = new Mock<Guy>(); // Create a mock guy.
	guy.Setup(guy => guy.Armor).Returns(50); // We have 50 armor.
	guy.Setup(guy => guy.TakeDamage(25)); // Create an expectation that guy.TakeDamage will be called with 25 as its argument.
	var damageDealer = new DamageDealer();
	damageDealer.DealDamage(guy, 75); // Deal 75 damage, which becomes 25 damage after armor.

We could test this using a real instance of Guy, but if Armor is calculated based on his level, skill points, equipment, and so on, it might be overly complicated to set up the correct scenario and force us to revisit the test if the Armor calculation ever changes -- that's not what we want at all.

Using a mock allowed us to only test the things that actually matter to us, protecting us from the implementation details of our dependencies and making it easier to set up our scenario. It comes at the expense of writing "fake" code -- if this were the only test that involved Guy.TakeDamage(), and that method was totally broken, we would not catch it because we are mocking it out.

# The kinds of tests
There are three categories that you'll hear most often with respect to testing: integration tests, functional tests, and unit tests. They each adopt a different perspective and have slightly different goals.

## Integration tests
Integration tests are the highest-level tests. They take the user's perspective and walk through an entire feature. They form the acceptance criteria for a feature -- when they are all passing, the feature is considered done. They tend to be written in a language that a non-technical stakeholder can understand, such as Cucumber.

	Scenario: Scoring a point
		Given I am playing a game of Pong
		And I have a ball coming at me
		And I hit the ball
		When my opponent misses the ball
		Then my score should be 1

They tend to only cover "happy path" cases, talk about "visible" outcomes rather than raw data structures, and almost never use mocks.

## Functional tests
A functional test represents the user performing a discrete interaction with the system. For a web app, this is submitting a form, clicking a button, or requesting a web page. For a game, it means moving your character, using a skill, or wielding your weapon.

Functional tests are written from the perspective of the system itself, may cover degenerate cases, deal with high-level data structures, and may use mocks to a limited extent.

	var shootingGame = LoadShootingGameWithMeLookingAtEnemy1();
	Assert.That(shootingGame.Enemies.First().IsAlive);
	Assert.That(shootingGame.MyAmmo, Is.EqualTo(50));
	shootingGame.Shoot();
	shootingGame.ProcessTime(10); // 10ms pass.
	Assert.That(shootingGame.Enemies.First().IsDead);
	Assert.That(shootingGame.MyAmmo, Is.EqualTo(49));

Functional tests form the specification of your high-level API. Here, you can see that I have a pre-constructed scenario to put the game into the right state for me to explode some poor sap's face. I make a couple of sanity checks, call the high-level method that represents the action the player is taking, simulate 10ms of game time to allow my explosion to take effect, then check that my ammo went down and so did the bad guy.

## Unit tests
Unit tests are the lowest-level tests, and are used to describe individual methods on an object. Unit tests tend to make heavier use of interaction-based testing. They goal is to cover every possible code path of a method, so most methods will have multiple test cases associated with them, covering both the normal and degenerate cases. This is where most of the bug-catching happens; it's also where we sketch out the interface of a class.

	Assert.That(rock.Beats(scissors));
	Assert.False(rock.Beats(rock));
	Assert.That(() => rock.Beats(null), Throws.Exception);

# TDD in the wild
Now let's try test-driving Pong.

## 92dec49
This is our starting point. We've got a test environment set up and three failing tests.

### GameStart.feature
I picked a simple rule to start with: when two players join the game, the game starts.

	Feature: Game starting

	Scenario: The game starts when two players join
	    Given I have a game of Pong
	    When two players join
	    Then the game starts

### JoinTest.cs
I broke that integration test down into a single functional test. I put it in a file called JoinTest.cs, which I anticipate will contain every test related to the PongGame.Join() method.

	[Test]
	public void Last_player_joining_starts_game()
	{
		Game.Join(new Player());
		Game.Join(new Player());
		Assert.That(Game.HasStarted);
	}

Notice that I'm using really high-level vocabulary here, using PongGame as my interface to any action I want to take or question I want to ask.

### PongGameTest.cs
I further broke that functional test down into the first unit test.

	[Test]
	public void Join_adds_player_to_players_list()
	{
		var player1 = new Player();
		var player2 = new Player();
		Game.Join(player1);
		Game.Join(player2);
		Assert.That(Game.Players, Is.EqualTo(new Player[] { player1, player2 }));
	}

Not terribly different from the functional test here, which is to be expected since this unit test deals with PongGame.Join() in the same way, but it introduces the concept of the PongGame.Players array. This is a detail that we didn't care about at the functional level, but it's a state change that we do need to care about if we're going to be able to implement the PongGame.HasStarted property.

## 7ab2503
### PongGameTest.cs
Here, I add another unit test to demonstrate the state transition of PongGame.HasStarted

	[Test]
	public void Join_starts_game_when_last_player_joins()
	{
		var player1 = new Player();
		var player2 = new Player();
		Game.Join(player1);
		Game.Join(player2);
		Assert.That(Game.HasStarted);
	}

## 23f89a
### PongGameTest.cs
Here, I made a decision that PongGame would be fed the number of players rather than having it assume there are two, and that the Players array would be full of null references initially.

	[Test]
	public void Constructor_allocates_players_list()
	{
		Game = new PongGame(5);
		Assert.That(Game.Players, Has.Length.EqualTo(5));
		Assert.That(Game.Players, Has.All.Null);
	}

The setup of my other tests changed as a result and I decided to make a helper method SetUp2PlayerPongGame() so I can freely change the constructor of PongGame without having the update every test individually.

### PongGame.cs
After running the tests and seeing them all fail, I implemented the constructor.

	public PongGame(int numberOfPlayers)
	{
		players = Enumerable.Repeat<IPlayer>(null, numberOfPlayers).ToArray();
	}

## ee5b7d
### PongGame.cs
With these two methods, all my tests are now passing.

	public void Join(IPlayer player)
	{
		players[Array.IndexOf(players, null)] = player;
	}

	public bool HasStarted
	{
		get { return players.All(player => players != null); }
	}

Notice that I'm being really cheesy here, deliberately doing *the simplest thing that could possibly work*.

Writing stuff like this can be scary, because it looks like the code is *wrong*, but at the moment it's actually *right*, because all that I claim the system does is say "Yes I've started" after two players have joined. If I went any further, I would be writing functionality that didn't have a test yet.

It's worth mentioning here that it's perfectly okay to aim for the "real" implementation first. If I had written a more rigorous test, or if I had more of the API fleshed out, it would be trivial to stump this cheesy implementation. However, if you're in unfamiliar territory and you're not confident about what to go next, it's always best to "fake it until you make it" and gradually work up to the final implementation.

## ???
Okay, now that our system is capable of something, let's hook it up to some input and a renderer so we can see it in action.