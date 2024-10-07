#include "../segment.h"
#include "../point.h"

namespace geometry {
Point::Point() : x_(0), y_(0) {
}
Point::Point(double x, double y) : x_(x), y_(y) {
}
IShape &Point::Move(const Vector &vector) {
  x_ += vector.x_;
  y_ += vector.y_;
  return *this;
}
bool Point::ContainsPoint(const Point &point) const {
  return (x_ == point.x_ && y_ == point.y_);
}

bool Point::CrossesSegment(const Segment &segment) const {
  return segment.ContainsPoint(*this);
}
IShape *Point::Clone() const {
  return new Point(*this);
}
std::string Point::ToString() {
  return "Point(" + std::to_string(static_cast<int>(x_)) + ", " + std::to_string(static_cast<int>(y_)) + ")";
}

Vector operator-(const Point &lhs, const Point &rhs) {
  return {lhs.x_ - rhs.x_, lhs.y_ - rhs.y_};
}
Vector operator+(const Point &lhs, const Point &rhs) {
  return {lhs.x_ + rhs.x_, lhs.y_ + rhs.y_};
}
bool operator==(const Point &lhs, const Point &rhs) {
  return (lhs.x_ == rhs.x_) && (lhs.y_ == rhs.y_);
}
}  // namespace geometry