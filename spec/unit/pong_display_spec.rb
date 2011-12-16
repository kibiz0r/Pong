require "spec_helper"

describe PongDisplay do
  dependencies :screen_renderer, :player_slot_renderer, :ball_renderer, :paddle_renderer

  before do
    assume IPongGame, :pong_game
    assume IPlayerSlot, :player_slot1, :player_slot2
    stub(@player_slot_renderer).render
    stub(@pong_game).player_slots { [@player_slot1, @player_slot2].of_type(IPlayerSlot) }
    stub(@pong_game).has_started { false }
    stub(@screen_renderer).clear
    stub(@screen_renderer).flip
  end

  describe "#render" do
    it "clears the screen" do
      mock(@screen_renderer).clear
      subject.render @pong_game
    end

    it "flips the screen" do
      mock(@screen_renderer).flip
      subject.render @pong_game
    end

    it "renders player slots" do
      mock(@player_slot_renderer).render @player_slot1
      mock(@player_slot_renderer).render @player_slot2
      subject.render @pong_game
    end

    context "when the game has started" do
      before do
        stub(@pong_game).has_started { true }
        assume IBall, :ball
        stub(@pong_game).ball { @ball }
        assume IPlayer, :player1, :player2
        stub(@pong_game).players { [@player1, @player2].of_type(IPlayer) }
        assume IPaddle, :paddle1, :paddle2
        stub(@player1).paddle { @paddle1 }
        stub(@player2).paddle { @paddle2 }
        stub(@ball_renderer).render
        stub(@paddle_renderer).render
      end

      it "renders the ball" do
        mock(@ball_renderer).render @ball
        subject.render @pong_game
      end

      it "renders the paddles" do
        mock(@paddle_renderer).render @paddle1
        mock(@paddle_renderer).render @paddle2
        subject.render @pong_game
      end
    end
  end
end
