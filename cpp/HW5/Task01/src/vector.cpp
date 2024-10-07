#include "../vector.h"

namespace geometry {
Vector::Vector() : x_(0), y_(0) {
}
Vector::Vector(double x, double y) : x_(x), y_(y) {
}
Vector Vector::operator+() const {
  return {};
}
Vector Vector::operator-() const {
  return {-x_, -y_};
}
Vector Vector::operator+=(Vector rhs) {
  *this = *this + rhs;
  return *this;
}
Vector Vector::operator-=(Vector rhs) {
  *this = *this - rhs;
  return *this;
}
Vector Vector::operator*=(int scalar) {
  *this = *this * scalar;
  return *this;
}
Vector Vector::operator/=(int scalar) {
  *this = *this / scalar;
  return *this;
}
bool Vector::operator==(Vector rhs) const {
  return (x_ == rhs.x_ && y_ == rhs.y_);
}
std::string Vector::ToString() const {
  return "Vector(" + std::to_string(static_cast<int>(x_)) + ", " + std::to_string(static_cast<int>(y_)) + ")";
}

Vector operator+(const Vector lhs, const Vector rhs) {
  return {lhs.x_ + rhs.x_, lhs.y_ + rhs.y_};
}
Vector operator-(const Vector lhs, const Vector rhs) {
  return lhs + (-rhs);
}
Vector operator*(Vector vector, int scalar) {
  return {vector.x_ * scalar, vector.y_ * scalar};
}
Vector operator*(int scalar, Vector vector) {
  return vector * scalar;
}
Vector operator/(Vector vector, int scalar) {
  return {vector.x_ / scalar, vector.y_ / scalar};
}

bool IsCollinear(const Vector &lhs, const Vector &rhs) {
  return (lhs.x_ / lhs.y_ == rhs.x_ / rhs.y_);
}
double DotProduct(const Vector &lhs, const Vector &rhs) {
  return lhs.x_ * rhs.x_ + lhs.y_ * rhs.y_;
}
bool IsSameDirection(const Vector &lhs, const Vector &rhs) {
  return (IsCollinear(lhs, rhs) && DotProduct(lhs, rhs) > 0) || rhs == Vector(0, 0) || lhs == Vector(0, 0);
}
}  // namespace geometry
