#include "../circle.h"
#include "cmath"
namespace geometry {
Circle::Circle() : center_(Point(0, 0)), radius_(0) {
}
Circle::Circle(Point center, int radius) : center_(std::move(center)), radius_(radius) {
}

IShape &Circle::Move(const Vector &vector) {
  center_.Move(vector);
  return *this;
}

bool Circle::ContainsPoint(const Point &point) const {
  return std::sqrt(std::pow(center_.x_ - point.x_, 2) + std::pow(center_.y_ - point.y_, 2)) <= radius_;
}

bool Circle::CrossesSegment(const Segment &segment) const {
  const double a_coeff = pow(segment.p2_.x_ - segment.p1_.x_, 2) + pow(segment.p2_.y_ - segment.p1_.y_, 2);
  const double b_coeff = 2 * ((segment.p2_.x_ - segment.p1_.x_) * (segment.p1_.x_ - center_.x_) +
                              (segment.p2_.y_ - segment.p1_.y_) * (segment.p1_.y_ - center_.y_));
  const double c_coeff = pow(segment.p1_.x_ - center_.x_, 2) + pow(segment.p1_.y_ - center_.y_, 2) - pow(radius_, 2);
  const double discriminant = pow(b_coeff, 2) - 4 * a_coeff * c_coeff;

  if (discriminant < 0) {
    return false;
  } else if (discriminant == 0) {
    const double t = -b_coeff / (2 * a_coeff);
    return t >= 0 && t <= 1;
  } else {
    const double t1 = (-b_coeff + sqrt(discriminant)) / (2 * a_coeff);
    const double t2 = (-b_coeff - sqrt(discriminant)) / (2 * a_coeff);
    return (t1 >= 0 && t1 <= 1) || (t2 >= 0 && t2 <= 1);
  }
}
IShape *Circle::Clone() const {
  return new Circle(*this);
}
std::string Circle::ToString() {
  return "Circle(" + center_.ToString() + ", " + std::to_string(radius_) + ")";
}
}  // namespace geometry