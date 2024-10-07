#include <iostream>
#pragma once
namespace geometry {
class Vector {
 public:
  double x_;
  double y_;
  Vector();
  Vector(double x, double y);

  Vector operator+() const;
  Vector operator-() const;

  Vector operator+=(Vector rhs);
  Vector operator-=(Vector rhs);
  Vector operator*=(int scalar);
  Vector operator/=(int scalar);

  bool operator==(Vector rhs) const;

  std::string ToString() const;
};

Vector operator+(Vector lhs, Vector rhs);
Vector operator-(Vector lhs, Vector rhs);
Vector operator*(Vector vector, int scalar);
Vector operator*(int scalar, Vector vector);
Vector operator/(Vector vector, int scalar);

bool IsCollinear(const Vector &lhs, const Vector &rhs);
double DotProduct(const Vector &lhs, const Vector &rhs);
bool IsSameDirection(const Vector &lhs, const Vector &rhs);
}  // namespace geometry