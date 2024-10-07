#include "../segment.h"
#include "../line.h"

namespace geometry {
double FindY(const Line &l, double x) {
  return l.K() * x + l.B();
}

Point FindIntersection(const geometry::Line &l1, const geometry::Line &l2) {
  if (l1.p1_.x_ == l1.p2_.x_) {
    return {l1.p1_.x_, FindY(l2, l1.p1_.x_)};
  } else if (l2.p1_.x_ == l2.p2_.x_) {
    return {l2.p1_.x_, FindY(l1, l2.p1_.x_)};
  } else {
    return {(l2.B() - l1.B()) / (l1.K() - l2.K()), FindY(l1, (l2.B() - l1.B()) / (l1.K() - l2.K()))};
  }
}
}  // namespace geometry