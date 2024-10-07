#include "../polygon.h"
#include "../ray.h"
#include <utility>

namespace geometry {
Polygon::Polygon() : vertices_(std::vector<Point>{}) {
}
Polygon::Polygon(std::vector<Point> vertices) : vertices_(vertices) {
  vertices_optimized_.push_back(vertices[0]);
  for (unsigned int i = 1; i < vertices.size(); i++) {
    Point prev = vertices_optimized_.back();
    Point curr = vertices[i];
    Point next = vertices[(i + 1) % vertices.size()];
    if (!(curr.y_ == prev.y_ && curr.y_ == next.y_) && !(curr.x_ == prev.x_ && curr.x_ == next.x_)) {
      vertices_optimized_.push_back(curr);
    }
  }
}

IShape &Polygon::Move(const Vector &vector) {
  for (auto &point : vertices_) {
    point.Move(vector);
  }
  for (auto &point_optimized : vertices_optimized_) {
    point_optimized.Move(vector);
  }
  return *this;
}

bool Polygon::ContainsPoint(const Point &point) const {
  bool isInside = false;
  Ray crossing_ray = Ray(point, Point(point.x_ + 1, point.y_));
  for (unsigned int i = 0; i < vertices_optimized_.size(); i++) {
    Segment segment = Segment(vertices_optimized_[i % vertices_optimized_.size()],
                              vertices_optimized_[(i + 1) % vertices_optimized_.size()]);
    if (segment.ContainsPoint(point)) {
      return true;
    }
    if (crossing_ray.CrossesSegment(segment)) {
      isInside = !isInside;
    }
  }
  return isInside;
}
bool Polygon::CrossesSegment(const Segment &segment) const {
  for (unsigned int i = 0; i < vertices_.size(); i++) {
    Segment curr_segment = Segment(vertices_[i % vertices_.size()], vertices_[(i + 1) % vertices_.size()]);
    if (curr_segment.ContainsPoint(segment.p1_) || curr_segment.ContainsPoint(segment.p2_)) {
      return true;
    }
  }
  return ((ContainsPoint(segment.p1_) && !ContainsPoint(segment.p2_)) ||
          (ContainsPoint(segment.p2_) && !ContainsPoint(segment.p1_)));
}
IShape *Polygon::Clone() const {
  return new Polygon(*this);
}
std::string Polygon::ToString() {
  std::string result = "Polygon(";
  for (unsigned int i = 0; i + 1 < vertices_.size(); i++) {
    result += vertices_[i].ToString() + ", ";
  }
  result += vertices_.back().ToString() + ")";
  return result;
}
}  // namespace geometry