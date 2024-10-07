#pragma once
#include <iostream>

class RationalDivisionByZero : public std::runtime_error {
 public:
  RationalDivisionByZero() : std::runtime_error("RationalDivisionByZero") {
  }
};

class Rational {
  int numerator_;
  int denominator_;
 public:
  Rational();
  Rational(int numerator); // NOLINT
  Rational(int numerator, int denominator);

  int GetNumerator() const;
  int GetDenominator() const;
  void SetNumerator(int numerator);
  void SetDenominator(int denominator);
  void Simplify();

  Rational operator+() const;
  Rational operator-() const;

  Rational operator++();
  Rational operator--();

  Rational operator++(int);
  Rational operator--(int);

  friend std::ostream& operator<<(std::ostream& os, const Rational& rational);
  friend std::istream& operator>>(std::istream& is, Rational& rational);
};

Rational operator+(const Rational& lhs, const Rational& rhs);
Rational operator-(const Rational& lhs, const Rational& rhs);
Rational operator*(const Rational& lhs, const Rational& rhs);
Rational operator/(const Rational& lhs, const Rational& rhs);

Rational operator+=(Rational& lhs, const Rational& rhs);
Rational operator-=(Rational& lhs, const Rational& rhs);
Rational operator*=(Rational& lhs, const Rational& rhs);
Rational operator/=(Rational& lhs, const Rational& rhs);

bool operator>(const Rational& lhs, const Rational& rhs);

bool operator<(const Rational& lhs, const Rational& rhs);
bool operator>=(const Rational& lhs, const Rational& rhs);
bool operator<=(const Rational& lhs, const Rational& rhs);
bool operator==(const Rational& lhs, const Rational& rhs);
bool operator!=(const Rational& lhs, const Rational& rhs);