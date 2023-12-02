$(function () {
    
    var popay_data = {
  
  
  
  
  
        "deductions": [ { "ele": "L.B.Nagar", "val": 37500},
                        { "ele": "Charminar", "val": 192114},
                        { "ele": "Khairtabad", "val": 202872},
                        { "ele": "Secunderabad", "val": 541450},
                        { "ele": "Serilingampally", "val": 7500},
                        { "ele": "Kukatpally", "val": 133333 },
                       
                      ],
         "earnings":  [ 
                        { "ele": "Charminar", "val": 326667 },
                        { "ele": "Khairtabad", "val": 908887 },
                        { "ele": "Serilingampally", "val": 290000 },
                        { "ele": "Kukatpally", "val": 1173000 },
                        { "ele": "Secunderabad", "val": 422250 }
                      ],
        "currency": "cfa"
    };
  
  var classificationData = [], elementData = [];
  
  for (var i = 0, earnings_total = 0; i < popay_data.earnings.length; i += 1) {
    elementData.push( { "name": popay_data.earnings[i].ele, "y": popay_data.earnings[i].val});
    earnings_total = earnings_total + popay_data.earnings[i].val;
  };
  
  for (var i = 0, deductions_total = 0; i < popay_data.deductions.length; i += 1) {
    elementData.push( { "name": popay_data.deductions[i].ele, "y": popay_data.deductions[i].val});
    deductions_total = deductions_total + popay_data.deductions[i].val;
  };
  
  elementData.push({ "name": 'L.B.Nagar', "y": earnings_total - deductions_total });
  
  classificationData[0] = {
    name: 'Earnings',
    y: earnings_total,
    color: '#0094b3', // popay blue
    nrElements: popay_data.earnings.length
  };
  
  classificationData[1] = {
    name: 'Deductions',
    y: deductions_total,
    color: '#ED561B', // red alike
    nrElements: popay_data.deductions.length
  };
    
  classificationData[2] = {
    name: 'Net',
    y: earnings_total - deductions_total,
    color: '#50B432', // green alike
    nrElements: 1
  };
  
  // Add the color to the 2nd level array, a brightness variation for each base color (per classification)
  for (var i = 0, e = 0; i < 3; i += 1) {
    var elementsOfClass = classificationData[i].nrElements;
    
    for (var j = 0; j < elementsOfClass; j += 1) {
      // create n brightness adjustements, within the 25 pct range.
      var brightness = ( 1 - ( (elementsOfClass - j) / elementsOfClass)) / 4;
      elementData[e].color = Highcharts.Color(classificationData[i].color).brighten(brightness).get();
      e = e + 1;
    }
  };

  // Create the chart
  $('#chart1').highcharts({
      chart: { type: 'pie'},
      
      plotOptions: { 
        pie: { 
          center: ['50%', '50%'],
          startAngle: -100 // showing data starts at -90 degrees for both series
      }},
      series: [{
        name: 'Total', // shown in the tooltip
        data: classificationData,
        size: '60%', // inner donut
        dataLabels: {
            color: 'white',
            style: { "textShadow": "0 0 0 contrast, 0 0 0 contrast" },
            distance: -50
      } }, {
        name: popay_data.currency, // shown in the tooltip
        data: elementData,
        size: '100%',
        innerSize: '65%' // a little more then the 60% of the first serie
      }]
  });
});