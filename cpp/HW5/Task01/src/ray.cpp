#include "../ray.h"
#include "../line.h"
#include "../functions.h"
namespace geometry {
Ray::Ray() = default;
Ray::Ray(const Point &p_origin, const Point &p2) {
  p_origin_ = p_origin;
  v = Vector(p2 - p_origin);
}

IShape &Ray::Move(const Vector &vector) {
  p_origin_.Move(vector);
  return *this;
}

bool Ray::ContainsPoint(const Point &point) const {
  Vector p_origin_to_point = point - p_origin_;
  return IsSameDirection(v, p_origin_to_point);
}

bool Ray::CrossesSegment(const Segment &segment) const {
  Line l1 = Line(p_origin_, Point(p_origin_.x_ + v.x_, p_origin_.y_ + v.y_));
  if (l1.CrossesSegment(segment)) {
    if (l1.ContainsPoint(segment.p1_) && l1.ContainsPoint(segment.p2_)) {
      return IsSameDirection(v, segment.p1_ - p_origin_) || IsSameDirection(v, segment.p2_ - p_origin_);
    } else {
      return IsSameDirection(v, FindIntersection(l1, Line(segment.p1_, segment.p2_)) - p_origin_);
    }
  }
  return false;
}
IShape *Ray::Clone() const {
  return new Ray(*this);
}
std::string Ray::ToString() {
  return "Ray(" + p_origin_.ToString() + ", " + v.ToString() + ")";
}
}  // namespace geometry