using Core;
using FluentNHibernate.Mapping;

namespace Infrastructure
{
    public class VisitorMap : ClassMap<Visitor>
    {
        public VisitorMap()
        {
            Table("Visitor");
            DynamicUpdate();
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.PathAndQuerystring).Length(4000).Not.Nullable();
            Map(x => x.LoginName).Length(255).Not.Nullable();
            Map(x => x.Browser).Length(4000).Not.Nullable();
            Map(x => x.VisitDate).Not.Nullable();
            Map(x => x.IpAddress).Not.Nullable();
        }
    }
}

/*<?xml version="1.0" encoding="utf-8" ?>
<hibernate-mapping xmlns="urn:nhibernate-mapping-2.2"
									namespace="Core"
									assembly="Core">

	<class name="Visitor" table="Visitors"
				 dynamic-update="true">
		<id name="Id" column="Id" type="Guid">
			<generator class="guid.comb"/>
		</id>
		<property name="PathAndQuerystring" length="4000"
							not-null="true"/>
		<property name="LoginName" length="255" not-null="true"/>
		<property name="Browser" length="4000" not-null="true"/>
		<property name="VisitDate" not-null="true"/>
		<property name="IpAddress" not-null="true"/>
	</class>
</hibernate-mapping>*/