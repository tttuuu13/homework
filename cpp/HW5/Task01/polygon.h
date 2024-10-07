#pragma once
#include "segment.h"
#include "line.h"
#include <vector>
namespace geometry {

class Polygon : public IShape {
 public:
  std::vector<Point> vertices_;
  std::vector<Point> vertices_optimized_;

  Polygon();
  explicit Polygon(std::vector<Point> vertices);

  IShape &Move(const Vector &vector) override;
  bool ContainsPoint(const Point &point) const override;
  bool CrossesSegment(const Segment &segment) const override;
  IShape *Clone() const override;
  std::string ToString() override;
};
}  // namespace geometry
