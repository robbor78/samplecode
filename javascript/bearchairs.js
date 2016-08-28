//........
//Javascript to solve problem explained on: https://community.topcoder.com/stat?c=problem_statement&pm=14131


var sample = [
  {atLeast: [1,21,11,7], d: 10, expectedResult: [1, 21, 11, 31]},
  {atLeast: [1,21,11,7], d: 11, expectedResult: [1, 21, 32, 43]},
  {atLeast: [1000000,1000000,1000000,1], d: 1000000, expectedResult: [1000000, 2000000, 3000000, 4000000]},
  {atLeast: [1000000,1000000,1000000,1], d: 999999, expectedResult: [1000000, 1999999, 2999998, 1]}
];

setup();

sample.forEach(function(s) {
  var result = findPositions(s.atLeast, s.d);
  console.log(result);
  console.log(s.expectedResult.equals(result));
});

function findPositions(atLeast, d) {
  //console.log(atLeast);
  //console.log(d);

  var occupiedChairs = []; //sorted list of occupied chairs
  var result = []; //chair for each bear, in the order the bears entered the restaurant

  atLeast.forEach(function(requestedChair, bear, bears) {

    console.log('processing bear: '+bear+' requestedChair: ' +requestedChair);
    console.log('occupiedChairs: '+occupiedChairs);
    console.log('result: '+result);

    if (result.length==0) {
      result.push(requestedChair);
      occupiedChairs.push(requestedChair);
      return;
    }

    var inspect = 0;

    //can bear be insert before start of list ?
    if (occupiedChairs[0] > requestedChair) {
      if (occupiedChairs[0] - requestedChair >= d) {
        occupiedChairs = [requestedChair].concat(occupiedChairs);
        result.push(requestedChair);
        return;
      } else {
        requestedChair = occupiedChairs[0] + d;
        inspect++;
      }
    }

    var isInserted = false;
    for (inspect; inspect < occupiedChairs.length && !isInserted; inspect++) {
      var inspectChair = occupiedChairs[inspect];
      //console.log(inspect+' '+occupiedChairs.length);
      //console.log('inspecting: '+inspectChair);
      if (inspectChair == requestedChair) {
        console.log('equal');
        requestedChair = inspectChair + d;
        continue;
      }

      if (inspectChair < requestedChair) {
        if (inspectChair + d > requestedChair) {
          requestedChair = inspectChair + d;
        }
        continue;
      }

      if (inspectChair > requestedChair) {
        console.log('too big');
        if (inspectChair - d < requestedChair) {
          requestedChair = inspectChair + d;
          console.log('rc: '+requestedChair);
          continue;
        }
        console.log('splicing');
        occupiedChairs.splice(inspect, 0, requestedChair);
        result.push(requestedChair);
        isInserted = true;
      }
    }

    if (!isInserted) {
      console.log('last');
      occupiedChairs.push(requestedChair);
      result.push(requestedChair);

      console.log(requestedChair);
      console.log(occupiedChairs);
      console.log(result);

    }

      /*
      int minChairIndex = occupiedChairs.findIndex(function (chairNumber, index, array) {
        if (chairNumber == requestedChair) { return true; }
        if (chairNumber < requestedChair) {
          if (index+1 == array.length) {return true;}
          var nextChair = array[index+1];
          return nextChair > requestedChair;
        }
        return true;
      });

      int minChair = occupiedChairs[minChairIndex];

      if (minChair <= requestedChair) {

      } else {
        if (minChair - d >= 0 && minChair - d >= requestedChair) {
          occupiedChairs = [requestedChair].concat(occupiedChairs);
        } else {
          occupiedChairs.push(minChair + d);
        }
      }*/

  });

  return result;
}


function setup() {

  // Warn if overriding existing method
  if(Array.prototype.equals)
      console.warn("Overriding existing Array.prototype.equals. Possible causes: New API defines the method, there's a framework conflict or you've got double inclusions in your code.");
  // attach the .equals method to Array's prototype to call it on any array
  Array.prototype.equals = function (array) {
      // if the other array is a falsy value, return
      if (!array)
          return false;

      // compare lengths - can save a lot of time
      if (this.length != array.length)
          return false;

      for (var i = 0, l=this.length; i < l; i++) {
          // Check if we have nested arrays
          if (this[i] instanceof Array && array[i] instanceof Array) {
              // recurse into the nested arrays
              if (!this[i].equals(array[i]))
                  return false;
          }
          else if (this[i] != array[i]) {
              // Warning - two different object instances will never be equal: {x:20} != {x:20}
              return false;
          }
      }
      return true;
  }
  // Hide method from for-in loops
  Object.defineProperty(Array.prototype, "equals", {enumerable: false});

}
