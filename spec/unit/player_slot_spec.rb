require "spec_helper"

describe PlayerSlot do
  context "before a player joins" do
    it { should_not be_ready }
  end

  context "after a player joins" do
    before do
      subject.join assume(IPlayer)
    end
    it { should be_ready }
  end
end
