#ifndef _CASHIER_H_
#define _CASHIER_H_

#include <iostream>
#include <string>

#include "Common.h"

using namespace std;

class Cashier {
public:
Cashier(string name, TPtrShopQueue q) : name(name), q(q), isProcessing(false), isRunning(true) {}

  void Enqueue(TPtrCustomer c);
  void Run(struct tm now);

  bool IsRunning() { return isRunning;}
  bool IsProcessing() {return isProcessing;}
  void SetIsRunning(bool isRunning) {this->isRunning = isRunning;}

  TQueue::size_type GetLength() const;
  string GetName() const {return name;}

private:
  string name;
  TPtrShopQueue q;
  TPtrCustomer c;
  bool isProcessing;
  struct tm end;
  double durationSec;
  bool isRunning;
};

inline std::ostream& operator<<(std::ostream &strm, const Cashier &c) {
  return strm << "Cashier: " << c.GetName() << " with " << c.GetLength()  << " customer(s).";
}

#endif
