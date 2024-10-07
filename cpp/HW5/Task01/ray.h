#include "segment.h"
#include "line.h"
#pragma once
namespace geometry {
class Ray : public IShape {
 public:
  Point p_origin_;
  Vector v;

  Ray();
  Ray(const Point &p1, const Point &p2);

  IShape &Move(const Vector &vector) override;
  bool ContainsPoint(const Point &point) const override;
  bool CrossesSegment(const Segment &segment) const override;
  IShape *Clone() const override;
  std::string ToString() override;
};
}  // namespace geometry