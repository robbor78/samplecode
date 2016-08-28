#include "Cashier.h"
#include "Customer.h"
#include "ShopQueue.h"

void Cashier::Enqueue(TPtrCustomer c) {
  q->Add(c);
}

TQueue::size_type Cashier::GetLength() const {
  return q->GetLength();
}

void Cashier::Run(struct tm now) {
  if (isProcessing) {

    double diff = difftime(mktime(&end),mktime(&now));

    if (diff<0.0) {
      cout << name << "Finished serving customer: " << *c << endl;
      isProcessing = false;
    } else {
      cout << name << "Still busy. Remaining time " << diff << " sec. Queue length: " << q->GetLength() << endl;
      return;
    }
  }

   c = q->Process();

  if (c) {
    isProcessing = true;

    end = now;

    durationSec = (double)c->GetNumItems() + (double)2.0;

    end.tm_sec += (int)durationSec;

    mktime(&end);

    cout << name << "Start serving customer: " << *c << " will take " << durationSec << " sec." << endl;

  } else {
    cout << name << "Idle. No customer." << endl;
  }
}
