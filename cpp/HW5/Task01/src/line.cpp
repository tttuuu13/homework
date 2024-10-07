#include <utility>
#include "../functions.h"

namespace geometry {
Line::Line() = default;
Line::Line(Point p1, Point p2) : p1_(std::move(p1)), p2_(std::move(p2)) {
}

double Line::K() const {
  return static_cast<double>(p2_.y_ - p1_.y_) / (p2_.x_ - p1_.x_);
}
double Line::B() const {
  return p1_.y_ - K() * p1_.x_;
}

IShape &Line::Move(const Vector &vector) {
  p1_.Move(vector);
  p2_.Move(vector);
  return *this;
}

bool Line::ContainsPoint(const Point &point) const {
  if (p1_.x_ == p2_.x_) {
    return point.x_ == p1_.x_;
  }
  return (FindY(*this, point.x_) == point.y_);
}

bool Line::CrossesSegment(const Segment &segment) const {
  if (p1_.x_ == p2_.x_) {
    if (segment.p1_.x_ == segment.p2_.x_) {
      return segment.p1_.x_ == p1_.x_;
    }
    return (segment.p1_.x_ <= p1_.x_ && segment.p2_.x_ >= p2_.x_) ||
           (segment.p1_.x_ >= p1_.x_ && segment.p2_.x_ <= p2_.x_);
  } else if (segment.p1_.x_ == segment.p2_.x_) {
    return (FindY(*this, segment.p1_.x_) >= std::min(segment.p1_.y_, segment.p2_.y_)) &&
           ((FindY(*this, segment.p1_.x_) <= std::max(segment.p1_.y_, segment.p2_.y_)));
  } else {
    return (segment.p1_.y_ >= FindY(*this, segment.p1_.x_) && segment.p2_.y_ <= FindY(*this, segment.p2_.x_)) ||
           (segment.p1_.y_ <= FindY(*this, segment.p1_.x_) && segment.p2_.y_ >= FindY(*this, segment.p2_.x_));
  }
}

IShape *Line::Clone() const {
  return new Line(*this);
}
std::string Line::ToString() {
  return "Line(" + std::to_string(static_cast<int>(p2_.y_ - p1_.y_)) + ", " +
         std::to_string(static_cast<int>(p1_.x_ - p2_.x_)) + ", " +
         std::to_string(static_cast<int>(p2_.x_ * p1_.y_ - p1_.x_ * p2_.y_)) + ")";
}
}  // namespace geometry