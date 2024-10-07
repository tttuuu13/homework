#pragma once
#include "point.h"
#include "line.h"
namespace geometry {
class Segment : public IShape {
 public:
  Point p1_;
  Point p2_;

  Segment();
  Segment(Point p1, Point p2);

  IShape &Move(const Vector &vector) override;
  bool ContainsPoint(const Point &point) const override;
  bool CrossesSegment(const Segment &segment) const override;
  IShape *Clone() const override;
  std::string ToString() override;
};
}  // namespace geometry
