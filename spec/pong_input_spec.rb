require "spec_helper"

describe PongInput do
  dependency :keyboard_input

  before do
    assume IPlayerSlot, :player_slot1, :player_slot2
    stub(@player_slot1).start_key { Key.enter }
    stub(@player_slot2).start_key { Key.tab }
    assume IPongGame, :pong_game
    stub(@pong_game).player_slots { [@player_slot1, @player_slot2].of_type(IPlayerSlot) }
    stub(@keyboard_input).poll
    stub(@keyboard_input).is_pressed { false }
  end

  describe "#apply" do
    context "when player 1 presses start" do
      before do
        stub(@keyboard_input).is_pressed(Key.enter) { true }
      end

      it "joins player slot 1" do
        mock(@pong_game).join @player_slot1
        subject.apply @pong_game
      end
    end
  end
end
