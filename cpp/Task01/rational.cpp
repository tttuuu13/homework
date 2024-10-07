#include <iostream>
#include <numeric>
#include "rational.h"

Rational::Rational() : numerator_(0), denominator_(1) {}
Rational::Rational(int n) :numerator_(n), denominator_(1) {}
Rational::Rational(int n, int d) {
  if (d == 0) {
    throw RationalDivisionByZero{};
  }
  numerator_ = n;
  denominator_ = d;
  Simplify();
}
int Rational::GetNumerator() const {
  return numerator_;
}
int Rational::GetDenominator() const {
  return denominator_;
}
void Rational::SetNumerator(int n) {
  numerator_ = n;
  Simplify();
}
void Rational::SetDenominator(int d) {
  if (d == 0) {
    throw RationalDivisionByZero{};
  }
  denominator_ = d;
  Simplify();
}
void Rational::Simplify() {
  if (denominator_ < 0) {
    numerator_ *= -1;
    denominator_ *= -1;
  }
  int gcd = std::gcd(numerator_, denominator_);
  numerator_ /= gcd;
  denominator_ /= gcd;
}

Rational operator+(const Rational& lhs, const Rational& rhs) {
  int d = lhs.GetDenominator() * rhs.GetDenominator();
  int n = lhs.GetNumerator() * rhs.GetDenominator() + rhs.GetNumerator() * lhs.GetDenominator();
  return {n, d};
}

Rational operator-(const Rational& lhs, const Rational& rhs) {
  int d = lhs.GetDenominator() * rhs.GetDenominator();
  int n = lhs.GetNumerator() * rhs.GetDenominator() - rhs.GetNumerator() * lhs.GetDenominator();
  return {n, d};
}

Rational operator*(const Rational& lhs, const Rational& rhs) {
  return {lhs.GetNumerator() * rhs.GetNumerator(),
          lhs.GetDenominator() * rhs.GetDenominator()};
}

Rational operator/(const Rational& lhs, const Rational& rhs) {
  return {lhs.GetNumerator() * rhs.GetDenominator(),
          lhs.GetDenominator() * rhs.GetNumerator()};
}

Rational operator+=(Rational& lhs, const Rational& rhs) {
  Rational result = lhs + rhs;
  lhs.SetNumerator(result.GetNumerator());
  lhs.SetDenominator(result.GetDenominator());
  return lhs;
}

Rational operator-=(Rational& lhs, const Rational& rhs) {
  lhs = lhs - rhs;
  return lhs;
}

Rational operator*=(Rational& lhs, const Rational& rhs) {
  lhs = lhs * rhs;
  return lhs;
}

Rational operator/=(Rational& lhs, const Rational& rhs) {
  lhs = lhs / rhs;
  return lhs;
}

Rational Rational::operator+() const {
  return *this;
}

Rational Rational::operator-() const {
  return {GetNumerator() * -1, GetDenominator()};
}

Rational Rational::operator++() {
  *this += 1;
  return *this;
}

Rational Rational::operator--() {
  *this -= 1;
  return *this;
}

Rational Rational::operator++(int) {
  Rational old_value = *this;
  *this += 1;
  return old_value;
}

Rational Rational::operator--(int) {
  Rational old_value = *this;
  *this -= 1;
  return old_value;
}
bool operator>(const Rational& lhs, const Rational& rhs) {
  int lcm = std::lcm(lhs.GetDenominator(), rhs.GetDenominator());
  return (lhs.GetNumerator() * (lcm / lhs.GetDenominator()) > rhs.GetNumerator() * (lcm / rhs.GetDenominator()));
}

bool operator<(const Rational& lhs, const Rational& rhs) {
  return rhs > lhs;
}

bool operator>=(const Rational& lhs, const Rational& rhs) {
  return !(lhs < rhs);
}

bool operator<=(const Rational& lhs, const Rational& rhs) {
  return !(lhs > rhs);
}

bool operator==(const Rational& lhs, const Rational& rhs) {
  return (lhs.GetDenominator() == rhs.GetDenominator() && lhs.GetNumerator() == rhs.GetNumerator());
}

bool operator!=(const Rational& lhs, const Rational& rhs) {
  return !(lhs == rhs);
}

std::ostream& operator<<(std::ostream &os, const Rational &rational) {
  if (rational.denominator_ == 1) {
    os << rational.numerator_;
    return os;
  }
  os << rational.numerator_ << '/' << rational.denominator_;
  return os;
}

std::istream& operator>>(std::istream &is, Rational &rational) {
  int n = 0;
  int d = 1;
  is >> n;
  if (is.peek() == '/') {
    is.ignore(1);
    is >> d;
  }
  rational = Rational(n, d);
  return is;
}
