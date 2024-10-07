#pragma once
#include "IShape.h"
namespace geometry {
class Point : public IShape {
 public:
  double x_;
  double y_;
  Point();
  Point(double x, double y);

  IShape &Move(const Vector &vector) override;
  bool ContainsPoint(const Point &point) const override;
  bool CrossesSegment(const Segment &segment) const override;
  IShape *Clone() const override;
  std::string ToString() override;
};

Vector operator-(const Point &lhs, const Point &rhs);
Vector operator+(const Point &lhs, const Point &rhs);
bool operator==(const Point &lhs, const Point &rhs);
}  // namespace geometry
