public class Job
{
    private string _jobTitle;
    private string _companyName;
    private string _location;
    private string _startDate;
    private string _endDate;
    private string _description;


public Job(string jobTitle, string companyName, string location, string startDate, string endDate, string description)
{
    _jobTitle = jobTitle;
    _companyName = companyName;
    _location = location;
    _startDate = startDate;
    _endDate = endDate;
    _description = description;
}

public string CompanyName
{
    get {return _companyName; }
    set { _companyName = value; }
}


public void Display()
{
    Console.WriteLine($"{_jobTitle} ({_companyName}) {_startDate}-{_endDate}");
}
}