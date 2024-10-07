#pragma once
#include "segment.h"
namespace geometry {
class Line : public IShape {
 public:
  Point p1_;
  Point p2_;

  Line();
  Line(Point p1, Point p2);

  double K() const;
  double B() const;

  IShape &Move(const Vector &vector) override;
  bool ContainsPoint(const Point &point) const override;
  bool CrossesSegment(const Segment &segment) const override;
  IShape *Clone() const override;
  std::string ToString() override;
};
}  // namespace geometry
