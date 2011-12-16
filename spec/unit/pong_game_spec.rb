require "spec_helper"

describe PongGame do
  dependencies :game_initializer, :player_initializer, :player_factory,
    :ball_factory, :ball_initializer

  before do
    assume IPlayer, :player1, :player2
    assume IPlayerSlot, :player_slot1, :player_slot2
    property :player_slots => [@player_slot1, @player_slot2].of_type(IPlayerSlot)
  end

  describe "#join" do
    context "when the slot is occupied" do
      before do
        stub(@player_slot1).ready { true }
        stub(@player_slot2).ready { true }
      end

      it "ignores the join" do
        subject.join @player_slot1
      end
    end

    context "when the slot is unoccupied" do
      before do
        stub(@player_factory).create(@player_slot1) { @player1 }
        stub(@player_factory).create(@player_slot2) { @player2 }
        stub(@player_slot1).ready { false }
        stub(@player_slot2).ready { false }
      end

      it "assigns a player to the slot" do
        mock(@player_slot1).join(@player1)
        mock(@player_slot2).join(@player2)

        subject.join @player_slot1
        subject.join @player_slot2
      end
    end
  end

  context "no player slots are ready" do
    before do
      stub(@player_slot1).ready { false }
      stub(@player_slot2).ready { false }
    end

    it { should_not have_started }
  end

  context "some player slots are ready" do
    before do
      stub(@player_slot1).ready { false }
      stub(@player_slot2).ready { true }
    end

    it { should_not have_started }
  end

  context "all player slots are ready" do
    before do
      stub(@player_slot1).ready { true }
      stub(@player_slot2).ready { true }
    end

    it { should have_started }
  end

  context "before exit is called" do
    it { should be_running }
  end

  context "after exit is called" do
    before do
      subject.exit
    end

    it { should_not be_running }
  end
end
