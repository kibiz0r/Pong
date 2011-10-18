require "spec_helper"

describe PongGame do
  dependencies :game_initializer, :player_initializer, :player_factory,
    :ball_factory, :ball_initializer

  before do
    assume IPlayer, :player1, :player2
    assume IPlayerSlot, :player_slot1, :player_slot2
    stub(@player_slot1).is_ready { false }
    stub(@player_slot2).is_ready { false }
    dependency :player_slots => [@player_slot1, @player_slot2].of_type(IPlayerSlot)
  end

  describe "#join" do
    before do
      stub(@player_factory).create(@player_slot1) { @player1 }
      stub(@player_factory).create(@player_slot2) { @player2 }
    end

    it "assigns a player to the slot" do
      mock(@player_slot1).join(@player1)
      mock(@player_slot2).join(@player2)

      subject.join @player_slot1
      subject.join @player_slot2
    end
  end

  describe "#has_started" do
    it "is false when no player slots are ready" do
      stub(@player_slot1).is_ready { false }
      stub(@player_slot2).is_ready { false }

      subject.has_started.should be_false
    end

    it "is false when only some player slots are ready" do
      stub(@player_slot1).is_ready { false }
      stub(@player_slot2).is_ready { true }

      subject.has_started.should be_false
    end

    it "is true when all player slots are ready" do
      stub(@player_slot1).is_ready { true }
      stub(@player_slot2).is_ready { true }

      subject.has_started.should be_true
    end
  end
end
