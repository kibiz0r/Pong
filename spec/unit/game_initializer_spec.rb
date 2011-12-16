require "spec_helper"

describe GameInitializer do
  dependencies :player_initializer, :ball_factory, :ball_initializer

  before do
    assume IPlayer, :player1, :player2
    assume IPongGame, :pong_game => {
      :players => [@player1, @player2].of_type(IPlayer)
    }
  end

  describe "#initialize_game" do
    it "initializes the players" do
      mock(@player_initializer).initialize(@player1)
      mock(@player_initializer).initialize(@player2)
      subject.initialize_game @pong_game
    end
  end
end
