require "spec_helper"

describe BallFactory do
  describe "#create" do
    it "creates a ball with a given position" do
      ball = subject.create Point.new(20, 40)
      ball.should be_a(Ball)
      ball.position.should == Point.new(20, 40)
    end
  end
end
