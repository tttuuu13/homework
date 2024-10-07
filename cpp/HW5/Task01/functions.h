#pragma once
#include "line.h"

namespace geometry {
double FindY(const Line &l, double x);

Point FindIntersection(const geometry::Line &l1, const geometry::Line &l2);
}  // namespace geometry