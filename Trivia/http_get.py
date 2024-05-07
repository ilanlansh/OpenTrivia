try:

    import requests as rq;
    import sys;

    # Distinguish URL from command line arguments
    url = sys.argv[-1];

    # HTTP GET request to the URL
    res = rq.get(url);

    # Format response as JSON
    data = res.text;

    # Print the data to be captured
    print(data);

except:

    print("ERR!!!");