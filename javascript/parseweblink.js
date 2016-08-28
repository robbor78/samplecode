//........

//A JavaScript function to parse the HTTP header described by RFC 5988 (https://tools.ietf.org/html/rfc5988). The function takes as an argument the web link and returns an object that lets the programmer retrieve the “URI-Reference” and find out what the value for a specific “link-param” is, e.g. “media”.

//References:
//https://tools.ietf.org/html/rfc5988
//https://github.com/thlorenz/parse-link-header
//https://gist.github.com/niallo/3109252
//Mozilla Developer Network https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference

//Usage:
//To test the function using a built in sample link:
//node parseweblink.js
//To test using a link provided on the command line:
//node parseweblink.js link-goes-here

var testLinks = [
  '<http://www.cern.ch/TheBook/chapter2>; rel="Previous"',
  ' <../media/contrast.css>; rel="stylesheet alternate"; title="High Contrast Styles"; type="text/css"; media="screen"',
  '<../media/print.css>; rel="stylesheet"; type="text/css";       media="print"  ',
  '</>; rel="http://example.net/foo"'
];

var testLink = testLinks[1];
if (process.argv.length>2) {
  testLink = process.argv[2];
}

console.log('Parsing: '+testLink);

var result = parseLinkHeader(testLink);

console.log(result);
console.log('Uri-Reference: '+result.uri_reference);
console.log('Media: '+result.link_params['media']);

function parseLinkHeader(link) {
    var parts = link.split(';');

    var uri = parts[0].replace(/[<>]/g, '');
    var lp = parseParams(parts.slice(1));

    return {
      uri_reference: uri,
      link_params: lp,
    };
}

function parseParams(paramsArray) {

  var lp = [];
  paramsArray.forEach(function(entry) {
    var keyValue = entry.split('=');
    if (typeof keyValue !== 'undefined' && keyValue.length > 0) {
      var key = keyValue[0].trim();
      var value = '';
      if (keyValue.length > 1 && keyValue[1]) {
        value = parseParamValue(keyValue[1]);
      }
      lp[key] = value;
    }
  });

  return lp;
}

function parseParamValue(paramValue) {
  var value = '';
  if (typeof paramValue !== 'undefined' && paramValue.length > 0) {
    value = paramValue.replace(/["]/g,'').trim();
  }
  return value;
}
