require "spec_helper"

describe PlayerSlotRenderer do
  dependency :font_renderer

  before do
    assume IPlayerSlot, :player_slot => {
      :color => Color.new(1, 1, 0),
      :join_ready_position => Point.new(50, 100),
      :join_ready_font_draw_flags => FontDrawFlags.align_left,
      :join_text => "some join text",
      :ready_text => "some ready text"
    }
  end    

  describe "#render" do
    context "when player slot is not ready" do
      before do
        stub(@player_slot).ready { false }
      end

      it "prints join text" do
        mock(@font_renderer).render(@color, @join_ready_position, @join_ready_font_draw_flags, @join_text)
        subject.render @player_slot
      end
    end

    context "when player slot is ready" do
      before do
        stub(@player_slot).ready { true }
      end

      it "prints ready text" do
        mock(@font_renderer).render(@color, @join_ready_position, @join_ready_font_draw_flags, @ready_text)
        subject.render @player_slot
      end
    end
  end
end
