#include <utility>

#include "../segment.h"
#include "../line.h"
#include "../functions.h"

namespace geometry {
Segment::Segment() : p1_(Point()), p2_(Point()) {
}
Segment::Segment(Point p1, Point p2) : p1_(std::move(p1)), p2_(std::move(p2)) {
}

IShape &Segment::Move(const Vector &vector) {
  p1_.Move(vector);
  p2_.Move(vector);
  return *this;
}

bool Segment::ContainsPoint(const Point &point) const {
  if (p1_.x_ == p2_.x_) {
    return (point.y_ >= std::min(p1_.y_, p2_.y_) && point.y_ <= std::max(p1_.y_, p2_.y_) && point.x_ == p1_.x_);
  }
  return (point.x_ >= std::min(p1_.x_, p2_.x_) && point.x_ <= std::max(p1_.x_, p2_.x_)) &&
         (FindY(Line(p1_, p2_), point.x_) == point.y_);
}

bool Segment::CrossesSegment(const Segment &segment) const {
  Line l1 = Line(p1_, p2_);
  Line l2 = Line(segment.p1_, segment.p2_);
  if (l1.ContainsPoint(segment.p1_) && l1.ContainsPoint(segment.p2_)) {
    return ContainsPoint(segment.p1_) || ContainsPoint(segment.p2_);
  }
  return l1.CrossesSegment(segment) && l2.CrossesSegment(*this);
}

IShape *Segment::Clone() const {
  return new Segment(*this);
}

std::string Segment::ToString() {
  return "Segment(" + p1_.ToString() + ", " + p2_.ToString() + ")";
}
}  // namespace geometry