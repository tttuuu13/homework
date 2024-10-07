#pragma once
#include "segment.h"
namespace geometry {

class Circle : public IShape {
 public:
  Point center_;
  int radius_;

  Circle();
  Circle(Point center, int radius);

  IShape &Move(const Vector &vector) override;
  bool ContainsPoint(const Point &point) const override;
  bool CrossesSegment(const Segment &segment) const override;
  IShape *Clone() const override;
  std::string ToString() override;
};
}  // namespace geometry